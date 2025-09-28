using System;
using System.IO;
using System.Text;
using System.Globalization; // Cần cho Parse double quốc tế
using UtilityDLL; // Sử dụng DLL đa năng

public partial class api : System.Web.UI.Page
{
    // Cấu trúc tạm thời để nhận dữ liệu từ JSON
    private class InputData
    {
        public int Degree = 0;
        public double A = 0;
        public double B = 0;
        public double C = 0;
        public double D = 0; // Dùng để xác nhận input có đủ không
    }

    // Cấu trúc trả về
    private class OutputData
    {
        public bool Success = false;
        public string Message = "Lỗi không xác định.";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "application/json";
        OutputData output = new OutputData();

        if (Request.HttpMethod == "POST")
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.InputStream, Encoding.UTF8))
                {
                    string jsonInput = reader.ReadToEnd();
                    InputData input = ParseJsonInput(jsonInput);
                    output.Success = true;
                    if (input != null)
                    {
                        
                        GiaiPhuongTrinh pt = new GiaiPhuongTrinh();

                        if (input.Degree == 2)
                        {
                            pt.A = input.A;
                            pt.B = input.B;
                            pt.C = input.C;
                            output.Message = " Giải PT Bậc 2: " + pt.GiaiBac2();
                        }
                        else if (input.Degree == 3)
                        {
                            // PT bậc 3 đơn giản (x^3 + bx + c = 0)
                            // A được gửi là 1
                            output.Message = " Giải PT Bậc 3: " + pt.GiaiBac3DonGian(input.B, input.C);
                        }
                        else
                        {
                            output.Success = false;
                            output.Message = "Bậc phương trình không hợp lệ.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                output.Success = false;
                output.Message = "Lỗi xử lý máy chủ: " + ex.Message;
            }
        }
        else
        {
            output.Success = false;
            output.Message = "Chỉ chấp nhận phương thức POST.";
        }

        Response.Write(BuildJsonOutput(output));
        Response.End();
    }

    // Phương thức tự phân tích JSON đơn giản
    private InputData ParseJsonInput(string json)
    {
        InputData data = new InputData();
        try
        {
            // Phân tích chuỗi key:value (rất cơ bản, không xử lý mảng/nested objects)
            json = json.Trim().Trim('{', '}');
            string[] pairs = json.Split(',');

            foreach (string pair in pairs)
            {
                string[] keyValue = pair.Split(':');
                if (keyValue.Length == 2)
                {
                    string key = keyValue[0].Trim().Trim('"');
                    string value = keyValue[1].Trim();

                    switch (key)
                    {
                        case "Degree": data.Degree = int.Parse(value); break;
                        case "A": data.A = double.Parse(value, CultureInfo.InvariantCulture); break;
                        case "B": data.B = double.Parse(value, CultureInfo.InvariantCulture); break;
                        case "C": data.C = double.Parse(value, CultureInfo.InvariantCulture); break;
                        case "D": data.D = double.Parse(value, CultureInfo.InvariantCulture); break;
                    }
                }
            }
            return data;
        }
        catch { return null; }
    }

    // Phương thức tự tạo chuỗi JSON đơn giản
    private string BuildJsonOutput(OutputData output)
    {
        return string.Format("{{\"Success\": {0}, \"Message\": \"{1}\"}}",
            output.Success.ToString().ToLower(),
            output.Message.Replace("\"", "\\\"").Replace("\r\n", "\\n"));
    }
}