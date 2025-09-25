# Laptrinhweb_bai1
## Ph.1: 
## TẠO SOLUTION GỒM CÁC PROJECT SAU:
- DLL đa năng, keyword: c# window library -> Class Library (.NET Framework) bắt buộc sử dụng .NET Framework 2.0: 
giải bài toán: "Giai phương trình bậc 2,3" 
- biên dịch ra DLL. DLL độc lập vì nó ko nhập, ko xuất, nó nhận input truyền vào thuộc tính của nó, và trả về dữ liệu thông qua thuộc tính khác, hoặc thông qua giá trị trả về của hàm. Nó độc lập thì sẽ sử dụng được trên app dạng console (giao diện dòng lệnh - đen sì), cũng sử dụng được trên app desktop (dạng cửa sổ), và cũng sử dụng được trên web form (web chạy qua iis).

1. Cài .NET Framework 2.0. Sau đó tạo New Project với Templates sau:
<img width="683" height="233" alt="image" src="https://github.com/user-attachments/assets/4db8c334-7033-4b54-b8e9-2b69c871391b" />

2. Project mới e tên là: UtilityDLL > Class1.cs
3. Đi vào bài toán:
### Giải phương trình bậc 2:
    Dùng công thức Δ = b² – 4ac.
    Trả về chuỗi mô tả nghiệm:
    Nếu Δ < 0 → vô nghiệm.
    Nếu Δ = 0 → nghiệm kép x = -b/(2a).
    Nếu Δ > 0 → hai nghiệm phân biệt.
### Giải phương trình bậc 3:
thêm hàm giải phương trình bậc 3 dạng đặc biệt (không phải dạng tổng quát).
    Sử dụng công thức Cardano để tính nghiệm:
    delta > 0 → 1 nghiệm thực.
    delta = 0 → nghiệm thực bội.
    delta < 0 → 3 nghiệm thực.
Trả về chuỗi liệt kê nghiệm.

5. Biên dịch chương trình: lệnh "C:\Windows\Microsoft.NET\Framework\v2.0.50727\csc.exe" /target:library /out:UtilityDLL.dll Class1.cs
6. 

## Ph.2: 
Console app, bắt buộc sử dụng .NET Framework 2.0, sử dụng được DLL trên: nhập được input, gọi DLL, hiển thị kết quả, phải có dấu án cá nhân. keyword: c# window Console => Console App (.NET Framework), biên dịch ra EXE

1. tạo New Project với Templates Console app:
<img width="780" height="318" alt="image" src="https://github.com/user-attachments/assets/041982fd-8485-4493-896b-0387ef21fcf7" />

2. Project mới e tên là: MyConsoleApp > Program.cs
3. Biên dịch bằng lệnh: "C:\Windows\Microsoft.NET\Framework\v2.0.50727\csc.exe" /out:C:\Users\Dell\source\repos\MyConsoleApp\MyConsoleApp.exe /reference:C:\Users\Dell\source\repos\UtilityDLL\UtilityDLL\UtilityDLL.dll C:\Users\Dell\source\repos\MyConsoleApp\MyConsoleApp\Program.cs
4. Trước khi kiểm thử cần: Đặt "UtilityDLL.dll" vào trong thư mục cùng cấp với "MyConsoleApp.exe" 
5. Run
<img width="1479" height="874" alt="image" src="https://github.com/user-attachments/assets/0a9ab27f-a218-48a7-8096-6a90e25560d4" />


## Ph.3:


