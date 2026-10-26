# Bài 1: MaHoaAes - Mã Hóa Đối Xứng AES-256

Phần mềm Windows Forms phát triển bằng C#, hỗ trợ mã hóa, giải mã văn bản và file dữ liệu dung lượng lớn sử dụng thuật toán đối xứng AES-256.

## 1. Quản lý Khóa (Key Management)
- **Sinh khóa mới:** Bấm "Sinh Khóa Mới (AES-256)" để tạo cặp `Key` và `IV` ngẫu nhiên.
- **Lưu/Import khóa:** Dùng nút "Lưu Khóa ra File" để cất file khóa hoặc "Import Khóa" để nạp khóa cũ từ thư mục `D:\Project\DuongHuuTao\MaHoaAes\Data`.

## 2. Mã hóa / Giải mã Văn bản
- **Mã hóa:** Gõ đoạn văn bản vào ô `Plaintext` rồi bấm "Mã hóa Văn bản" để lấy chuỗi mã hóa dạng Base64.
- **Giải mã:** Dán chuỗi mã hóa Base64 vào ô `Kết quả` rồi bấm "Giải mã Văn bản" để xem lại nội dung ban đầu.

## 3. Mã hóa / Giải mã File và Kiểm tra Hiệu năng
- **Chọn file:** Nhấn chọn đường dẫn cho `File Nguồn` và `File Kết quả`.
- **Xử lý file:** Nhấn "Mã hóa File" hoặc "Giải mã File" để xử lý:
  - Chương trình hỗ trợ file dung lượng lớn hàng GB bằng `CryptoStream`.
  - Hiển thị thanh chạy phần trăm `ProgressBar`.
  - Đo thời gian thực hiện bằng `Stopwatch`.
- **So sánh file:** Nhấn "So sánh Byte 2 File" để đối chiếu file gốc và file giải mã xem có khớp từng byte một hay không.

---

# Bài 2: MaHoaRsa - Mã Hóa Bất Đối Xứng RSA & Chữ Ký Số

Phần mềm Windows Forms phát triển bằng C#, hỗ trợ quản lý cặp khóa bất đối xứng RSA-2048, mã hóa/giải mã văn bản ngắn, tính hàm băm SHA-256, tạo chữ ký số RSA-PSS và đánh giá hiệu năng tốc độ thực thi.

## 1. Quản lý Khóa (Key Management)
- **Sinh khóa mới:** Bấm "Sinh Khóa (RSA-2048)" để tạo cặp khóa công khai (`Public Key`) và khóa bí mật (`Private Key`) ngẫu nhiên.
- **Lưu/Xuất khóa ra file:** Dùng nút "Xuất Khóa ra File" để lưu định dạng PEM (`public_key.pem`, `private_key.pem`) vào thư mục dự án.
- **Import khóa PEM:** Dùng nút "Import Khóa PEM..." để nạp khóa cũ từ file PEM.
- **Xem cấu trúc PEM:** Bấm "Xem Cấu Trúc PEM" để kiểm tra định dạng và ý nghĩa các thành phần byte bên trong khóa.

## 2. Mã hóa / Giải mã Văn bản & Hàm băm SHA-256
- **Mã hóa RSA:** Gõ đoạn văn bản vào ô `Văn bản (Plaintext)` rồi bấm "Mã hóa RSA" để lấy chuỗi mã hóa dạng Base64 (giới hạn tối đa 190 byte với RSA 2048-bit và OAEP padding).
- **Giải mã RSA:** Bấm "Giải mã RSA" để phục hồi nội dung văn bản gốc từ chuỗi mã hóa và đối chiếu độ chính xác 100%.
- **Hàm băm SHA-256:** Bấm "Băm SHA-256" để kiểm tra hiệu ứng tuyết rơi (Avalanche Effect) - khi thay đổi dù chỉ 1 ký tự ở đầu vào, giá trị mã băm thay đổi hoàn toàn khác biệt.

## 3. Chữ ký số RSA-PSS & Đánh giá Hiệu năng
- **Chữ ký số RSA-PSS:** Nhấn "Chữ ký số RSA-PSS" để thực hiện ký số văn bản bằng khóa bí mật. Chương trình minh họa tính năng: cùng dữ liệu và cùng người ký nhưng chữ ký số ở các lần ký khác nhau do sử dụng salt ngẫu nhiên, đồng thời tự động xác thực tính hợp lệ bằng khóa công khai.
- **Đánh giá hiệu năng tốc độ:** Nhấn "Đánh giá Tốc độ" để đo thời gian thực thi hàng loạt giữa phép mã hóa (sử dụng số mũ công khai $e$ nhỏ) và phép giải mã (sử dụng số mũ bí mật $d$ lớn) qua `Stopwatch` kết hợp thanh tiến trình `ProgressBar`.