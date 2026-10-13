using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab06_QuanLySanPham
{
    /// <summary>
    /// Module xử lý lưu trữ và xuất/nhập dữ liệu độc lập, thuần .NET Framework, không phụ thuộc NuGet ngoài.
    /// </summary>
    public static class ProductStorage
    {
        private static readonly string StorageFileName = "products.json";

        public static string GetStorageFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, StorageFileName);
        }

        public static string GetImagesDirectory()
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }

        #region LƯU TRỮ VÀ NẠP JSON

        public static List<Product> LoadProducts()
        {
            string path = GetStorageFilePath();
            if (!File.Exists(path))
            {
                var defaultList = GetDefaultProducts();
                SaveProducts(defaultList);
                return defaultList;
            }

            try
            {
                string json = File.ReadAllText(path, Encoding.UTF8);
                var list = ParseJsonToProducts(json);
                if (list == null || list.Count == 0)
                {
                    return GetDefaultProducts();
                }
                return list;
            }
            catch
            {
                return GetDefaultProducts();
            }
        }

        public static bool SaveProducts(IEnumerable<Product> products)
        {
            try
            {
                string path = GetStorageFilePath();
                string json = SerializeToJson(products);
                File.WriteAllText(path, json, Encoding.UTF8);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static List<Product> GetDefaultProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    MaSP = "SP01",
                    TenSP = "Bàn phím cơ AKKO 3087 v2",
                    LoaiSP = "Điện tử",
                    DonGia = 1250000m,
                    SoLuong = 15,
                    NgayNhap = DateTime.Now.AddDays(-15),
                    ConKinhDoanh = true
                },
                new Product
                {
                    MaSP = "SP02",
                    TenSP = "Ghế công thái học Sihoo M57",
                    LoaiSP = "Văn phòng",
                    DonGia = 3450000m,
                    SoLuong = 4, // Sắp hết hàng
                    NgayNhap = DateTime.Now.AddDays(-10),
                    ConKinhDoanh = true
                },
                new Product
                {
                    MaSP = "SP03",
                    TenSP = "Nồi chiên không dầu Philips HD9252",
                    LoaiSP = "Gia dụng",
                    DonGia = 2190000m,
                    SoLuong = 20,
                    NgayNhap = DateTime.Now.AddDays(-7),
                    ConKinhDoanh = true
                },
                new Product
                {
                    MaSP = "SP04",
                    TenSP = "Áo khoác gió thể thao Uniqlo UV",
                    LoaiSP = "Thời trang",
                    DonGia = 590000m,
                    SoLuong = 0, // Hết hàng
                    NgayNhap = DateTime.Now.AddDays(-30),
                    ConKinhDoanh = true
                },
                new Product
                {
                    MaSP = "SP05",
                    TenSP = "Màn hình Dell UltraSharp U2422H",
                    LoaiSP = "Điện tử",
                    DonGia = 5890000m,
                    SoLuong = 8,
                    NgayNhap = DateTime.Now.AddDays(-3),
                    ConKinhDoanh = true
                },
                new Product
                {
                    MaSP = "SP06",
                    TenSP = "Bút ký cao cấp Parker Jotter",
                    LoaiSP = "Văn phòng",
                    DonGia = 450000m,
                    SoLuong = 2, // Sắp hết hàng
                    NgayNhap = DateTime.Now.AddDays(-20),
                    ConKinhDoanh = false // Ngừng bán
                }
            };
        }

        #endregion

        #region BỘ CHUYỂN ĐỔI JSON THUẦN TÚY (ZERO DEPENDENCY)

        private static string SerializeToJson(IEnumerable<Product> list)
        {
            var sb = new StringBuilder();
            sb.AppendLine("[");
            bool first = true;
            foreach (var p in list)
            {
                if (!first) sb.AppendLine(",");
                first = false;

                sb.AppendLine("  {");
                sb.AppendLine($"    \"MaSP\": \"{EscapeJson(p.MaSP)}\",");
                sb.AppendLine($"    \"TenSP\": \"{EscapeJson(p.TenSP)}\",");
                sb.AppendLine($"    \"LoaiSP\": \"{EscapeJson(p.LoaiSP)}\",");
                sb.AppendLine($"    \"DonGia\": {p.DonGia.ToString(CultureInfo.InvariantCulture)},");
                sb.AppendLine($"    \"SoLuong\": {p.SoLuong},");
                sb.AppendLine($"    \"NgayNhap\": \"{p.NgayNhap:yyyy-MM-ddTHH:mm:ss}\",");
                sb.AppendLine($"    \"ConKinhDoanh\": {(p.ConKinhDoanh ? "true" : "false")},");
                sb.AppendLine($"    \"DuongDanAnh\": \"{EscapeJson(p.DuongDanAnh)}\"");
                sb.Append("  }");
            }
            sb.AppendLine();
            sb.AppendLine("]");
            return sb.ToString();
        }

        private static List<Product> ParseJsonToProducts(string json)
        {
            var result = new List<Product>();
            if (string.IsNullOrWhiteSpace(json)) return result;

            // Tách từng object {...}
            var matches = Regex.Matches(json, @"\{([^{}]+)\}");
            foreach (Match m in matches)
            {
                string block = m.Groups[1].Value;
                var p = new Product();

                p.MaSP = ExtractJsonString(block, "MaSP");
                p.TenSP = ExtractJsonString(block, "TenSP");
                p.LoaiSP = ExtractJsonString(block, "LoaiSP");
                p.DonGia = ExtractJsonDecimal(block, "DonGia");
                p.SoLuong = ExtractJsonInt(block, "SoLuong");
                p.NgayNhap = ExtractJsonDate(block, "NgayNhap");
                p.ConKinhDoanh = ExtractJsonBool(block, "ConKinhDoanh", true);
                p.DuongDanAnh = ExtractJsonString(block, "DuongDanAnh");

                if (!string.IsNullOrEmpty(p.MaSP))
                {
                    result.Add(p);
                }
            }
            return result;
        }

        private static string EscapeJson(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "\\n");
        }

        private static string UnescapeJson(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            return s.Replace("\\n", "\n").Replace("\\\"", "\"").Replace("\\\\", "\\");
        }

        private static string ExtractJsonString(string block, string key)
        {
            var match = Regex.Match(block, $"\"{key}\"\\s*:\\s*\"([^\"]*)\"");
            return match.Success ? UnescapeJson(match.Groups[1].Value) : string.Empty;
        }

        private static decimal ExtractJsonDecimal(string block, string key)
        {
            var match = Regex.Match(block, $"\"{key}\"\\s*:\\s*([0-9.]+)");
            if (match.Success && decimal.TryParse(match.Groups[1].Value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val))
                return val;
            return 0m;
        }

        private static int ExtractJsonInt(string block, string key)
        {
            var match = Regex.Match(block, $"\"{key}\"\\s*:\\s*([0-9-]+)");
            if (match.Success && int.TryParse(match.Groups[1].Value, out int val))
                return val;
            return 0;
        }

        private static bool ExtractJsonBool(string block, string key, bool defaultVal = true)
        {
            var match = Regex.Match(block, $"\"{key}\"\\s*:\\s*(true|false)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value.Equals("true", StringComparison.OrdinalIgnoreCase);
            }
            return defaultVal;
        }

        private static DateTime ExtractJsonDate(string block, string key)
        {
            var match = Regex.Match(block, $"\"{key}\"\\s*:\\s*\"([^\"]*)\"");
            if (match.Success && DateTime.TryParse(match.Groups[1].Value, out DateTime dt))
                return dt;
            return DateTime.Now;
        }

        #endregion

        #region XUẤT VÀ NHẬP EXCEL / CSV CHUẨN UTF-8

        public static void ExportToCsv(IEnumerable<Product> products, string filePath)
        {
            var sb = new StringBuilder();
            // Tiêu đề cột
            sb.AppendLine("Mã SP,Tên sản phẩm,Loại sản phẩm,Đơn giá (VNĐ),Số lượng,Thành tiền (VNĐ),Ngày nhập,Kinh doanh,Tình trạng kho");

            foreach (var p in products)
            {
                string line = string.Format(
                    "\"{0}\",\"{1}\",\"{2}\",{3},{4},{5},\"{6}\",\"{7}\",\"{8}\"",
                    p.MaSP.Replace("\"", "\"\""),
                    p.TenSP.Replace("\"", "\"\""),
                    p.LoaiSP.Replace("\"", "\"\""),
                    p.DonGia.ToString("F0", CultureInfo.InvariantCulture),
                    p.SoLuong,
                    p.ThanhTien.ToString("F0", CultureInfo.InvariantCulture),
                    p.NgayNhap.ToString("dd/MM/yyyy"),
                    p.ConKinhDoanh ? "Đang kinh doanh" : "Ngừng kinh doanh",
                    p.TinhTrangTonKhoText
                );
                sb.AppendLine(line);
            }

            // Ghi file kèm UTF-8 BOM để Excel tự động nhận font tiếng Việt có dấu
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        public static List<Product> ImportFromCsv(string filePath)
        {
            var list = new List<Product>();
            if (!File.Exists(filePath)) return list;

            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
            if (lines.Length <= 1) return list;

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line)) continue;

                var parts = ParseCsvLine(line);
                if (parts.Count >= 5)
                {
                    var p = new Product
                    {
                        MaSP = parts[0],
                        TenSP = parts[1],
                        LoaiSP = parts[2]
                    };

                    if (decimal.TryParse(parts[3], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal dg))
                        p.DonGia = dg;
                    if (int.TryParse(parts[4], out int sl))
                        p.SoLuong = sl;

                    if (parts.Count >= 7 && DateTime.TryParseExact(parts[6], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nn))
                        p.NgayNhap = nn;
                    else
                        p.NgayNhap = DateTime.Now;

                    if (parts.Count >= 8)
                        p.ConKinhDoanh = !parts[7].ToLower().Contains("ngừng");

                    list.Add(p);
                }
            }
            return list;
        }

        private static List<string> ParseCsvLine(string line)
        {
            var result = new List<string>();
            bool inQuotes = false;
            var current = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '\"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '\"')
                    {
                        current.Append('\"');
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    result.Add(current.ToString().Trim());
                    current.Clear();
                }
                else
                {
                    current.Append(c);
                }
            }
            result.Add(current.ToString().Trim());
            return result;
        }

        #endregion

        #region XỬ LÝ ẢNH AN TOÀN (KHÔNG KHÓA FILE)

        public static System.Drawing.Image LoadImageSafe(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return null;

            // Xử lý cả đường dẫn tương đối và tuyệt đối
            string fullPath = filePath;
            if (!Path.IsPathRooted(fullPath))
            {
                fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            }

            if (!File.Exists(fullPath)) return null;

            try
            {
                byte[] bytes = File.ReadAllBytes(fullPath);
                using (var ms = new MemoryStream(bytes))
                {
                    return System.Drawing.Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        public static string CopyImageToAppData(string sourceFilePath, string maSP)
        {
            if (string.IsNullOrEmpty(sourceFilePath) || !File.Exists(sourceFilePath))
                return string.Empty;

            try
            {
                string imagesDir = GetImagesDirectory();
                string ext = Path.GetExtension(sourceFilePath).ToLower();
                string newFileName = $"{maSP}_{Guid.NewGuid().ToString().Substring(0, 8)}{ext}";
                string destPath = Path.Combine(imagesDir, newFileName);

                File.Copy(sourceFilePath, destPath, true);

                // Trả về đường dẫn tương đối để dễ chuyển máy mà không mất liên kết
                return Path.Combine("Images", newFileName);
            }
            catch
            {
                return sourceFilePath;
            }
        }

        #endregion
    }
}
