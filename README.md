**Shipper Simulator: Đơn Hàng Tử Thần** là một dự án game 2D top-down lấy bối cảnh đường phố Việt Nam đầy sống động và thử thách. Trong game, người chơi sẽ hóa thân thành một shipper thực thụ, đối mặt với các nhiệm vụ giao hàng chạy đua với thời gian, đồng thời phải né tránh vô vàn chướng ngại vật "bá đạo" mang đậm tính chất meme và đời sống thực tế tại Việt Nam.

---

## 📋 Mục lục
- [Giới thiệu dự án](#-giới-thiệu-dự-án)
- [Các tính năng kỹ thuật](#-các-tính-năng-kỹ-thuật)
- [Hình ảnh trong game (Screenshots)](#-hình-ảnh-trong-game-screenshots)
- [Hướng dẫn điều khiển (Cách chơi)](#-hướng-dẫn-điều-khiển-cách-chơi)
- [Hướng dẫn cài đặt](#-hướng-dẫn-cài-đặt)
- [Danh sách thành viên & Phân công nhiệm vụ](#-danh-sách-thành-viên--phân-công-nhiệm-vụ)

---

## 🌟 Giới thiệu dự án

Game đặt người chơi vào vai một nhân viên giao hàng tại các thành phố Việt Nam. Nhiệm vụ chính của bạn là:
- Nhận đơn hàng, lấy hàng và nhanh chóng di chuyển đến điểm gửi hàng để giao đúng giờ quy định.
- Vượt qua các tình huống khó khăn và chướng ngại vật trên đường phố: xe cộ đông đúc, chó rượt đuổi, công an giao thông và các sự kiện bất ngờ mang tính hài hước (meme).
- Hoàn thành xuất sắc nhiều đơn hàng để tích lũy tiền tệ, phục vụ cho việc mua sắm vật phẩm cứu trợ và nâng cấp phương tiện di chuyển khỏe hơn, nhanh hơn.

---

## 🚀 Các tính năng kỹ thuật

Hệ thống mã nguồn và cấu trúc asset của trò chơi được xây dựng trên Engine Unity bao gồm:
- **Hệ thống vật lý 2D:** Sử dụng cấu trúc thành phần `Rigidbody2D` kết hợp `Collider2D` để xử lý mượt mà các va chạm, di chuyển và quán tính của xe.
- **Animation Sprite:** Xử lý các chuỗi khung hình chuyển động đa dạng cho nhân vật và phương tiện (`idle`, `run`, `drive`,... ).
- **Hệ thống tạo map Tilemap:** Thiết kế lưới ô gạch chi tiết cho đường xá, vỉa hè, các tòa nhà, khu di tích cổ và công viên đô thị.
- **UI Canvas:** Giao diện người dùng trực quan điều khiển hệ thống Menu chính, màn hình tạm dừng, cửa hàng và các thanh trạng thái chỉ số.
- **Random Event:** Cơ chế tạo các sự kiện ngẫu nhiên xuất hiện ngẫu hứng trên lộ trình giao hàng để gia tăng tính thử thách cho Player.

---

## 📸 Hình ảnh trong game (Screenshots)

Để người xem dễ dàng hình dung quy mô và các tính năng của dự án, dưới đây là toàn bộ danh sách hình ảnh thực tế được trích xuất trực tiếp từ bản build của trò chơi:

### 1. Giao diện & Hệ thống Menu điều khiển
* **Màn hình thông tin thành viên phát triển (`Screenshot 2026-05-11 143036.png`)**
  ![Thông tin thành viên](Screenshot%202026-05-11%20143036.png)
  *Bảng Pop-up hiển thị danh sách thành viên thực hiện dự án và phân chia chi tiết các module lập trình.*

* **Bảng hướng dẫn cách chơi và nút bấm tương tác (`Screenshot 2026-05-20 083438.png`)**
  ![Hướng dẫn cách chơi](Screenshot%202026-05-20%20083438.png)
  *Giao diện hướng dẫn chi tiết các phím chức năng điều khiển Shipper (WASD, Space, E, F, Tab).*

---

### 2. Thiết kế Bản đồ Đô thị & Chướng ngại vật (Gameplay Map)
* **Góc phố đô thị số 1 - Khu dân cư (`Screenshot 2026-05-20 085224.png`)**
  ![Khu dân cư](Screenshot%202026-05-20%20085224.png)
  *Hình ảnh lát cắt một phần bản đồ thành phố với hệ thống vỉa hè gạch đỏ, lòng đường và các dãy nhà cao tầng.*

* **Góc phố đô thị số 2 - Hàng quán vỉa hè (`Screenshot 2026-05-20 085247.png`)**
  ![Hàng quán vỉa hè](Screenshot%202026-05-20%20085247.png)
  *Chi tiết các tiệm kinh doanh dịch vụ mang bản sắc Việt Nam như quán "Phở Anh Hai" và tiệm cắt tóc "BHGaming".*

* **Khu vực tập kết rác thải và chướng ngại vật (`Screenshot 2026-05-20 085324.png`)**
  ![Chướng ngại vật trên phố](Screenshot%202026-05-20%20085324.png)
  *Mô tả các thùng rác công cộng, các túi rác tập kết bên lề đường tạo thành các vật cản thử thách tay lái của Shipper.*

---

### 3. Bản đồ Tổng thể & Kiến trúc Tâm linh Văn hóa
* **Bản đồ tổng quan khu di tích Đình - Chùa cổ kính (`Screenshot 2026-05-20 085403.png`)**
  ![Khu di tích cổ kính](Screenshot%202026-05-20%20085403.png)
  *Góc nhìn từ trên xuống bao quát toàn bộ kiến trúc tâm linh gồm mái ngói đỏ đan xen, sân gạch, lư hương trung tâm và ao sen.*

* **Mở rộng bản đồ - Liên kết các khu vực liền kề (`Screenshot 2026-05-20 085410.png`)**
  ![Bản đồ mở rộng](Screenshot%202026-05-20%20085410.png)
  *Hình ảnh thể hiện sự kết nối giữa khu phố hiện đại và khu di tích lịch sử thông qua các lối đi bằng gạch chi tiết.*

* **Quy hoạch tổng thể Grid Tilemap trên Unity (`Screenshot 2026-05-20 085427.png`)**
  ![Quy hoạch tổng thể](Screenshot%202026-05-20%20085427.png)
  *Bản vẽ thiết kế hệ thống lưới ô xám trống đang trong quá trình fill kín các tòa nhà và đường sá để mở rộng quy mô map bự.*

---

### 4. Hệ thống Tài nguyên & Hoạt họa Nhân vật (Assets)
* **Bảng Asset nhân vật và NPC Việt Nam (`Screenshot 2026-05-20 085800.png`)**
  ![Spritesheet NPC](Screenshot%202026-05-20%20085800.png)
  *Tập hợp các Sprite Sheet Pixel Art của các NPC đặc trưng: người bán bánh mì, cô bán hàng tạp hóa nón lá, người dân đi bộ...*

* **Bảng Asset vật phẩm và Đơn vị Tiền tệ (`Screenshot 2026-05-20 085840.png`)**
  ![Vật phẩm và Tiền tệ](Screenshot%202026-05-20%20085840.png)
  *Thiết kế chi tiết các item tiền polymer Việt Nam, các cọc tiền và tiền xu cổ dùng cho hệ thống giao dịch, nâng cấp xe trong cửa hàng.*
---

## 🎮 Hướng dẫn điều khiển (Cách chơi)

Hệ thống nút bấm tương tác trong game được cấu hình thiết lập chuẩn xác như sau:

| Thao tác hành động | Phím bấm điều khiển |
| :--- | :--- |
| **Di chuyển lên / xuống / qua / lại** | Phím `W`, `A`, `S`, `D` hoặc các phím Mũi tên (`↑`, `↓`, `←`, `→`) |
| **Tương tác (Nhận / Lấy / Giao hàng)** | Phím `E` (Khi tiếp cận NPC hoặc điểm đích) |
| **Lên xe / Xuống xe** | Phím `F` |
| **Màn hình dừng (Pause Menu)** | Phím `Tab` |

---

## ⚙️ Hướng dẫn cài đặt

### Dành cho Người chơi (Bản Build)
1. Tải bản nén thư mục cài đặt game từ mục **Releases** của repository này.
2. Giải nén tệp tin (`.zip` hoặc `.rar`) vào bộ nhớ máy tính.
3. Tìm và khởi chạy file thực thi `ShipperSimulation.exe` để vào game ngay lập tức mà không cần cài đặt thêm phần mềm bổ trợ.

### Dành cho Nhà phát triển (Source Code)
1. Tiến hành clone project về máy cá nhân:
git clone https://github.com/Rikokyu/Shipper-Game.git
2. Khởi động ứng dụng **Unity Hub**, chọn **Add project từ thư mục** và trỏ tới thư mục chứa source code vừa tải.
3. Sử dụng phiên bản **Unity 2022.3 LTS** (hoặc bản tương thích) để mở dự án và tự động đồng bộ hóa các package thiết lập `Tilemap`, `Physics2D` và `UI Canvas`.

---

## 👥 Danh sách thành viên & Phân công nhiệm vụ

Dự án được thực hiện toàn diện bởi các thành viên với phân mục thiết kế cụ thể:

* **Nguyễn Trung Hiệp** (MSSV: `2312610`)
    * *Phân công nhiệm vụ:* Quản lý và lập trình logic cho **Player**, Hệ thống nhiệm vụ đơn hàng (**Quest**), Hệ thống vật phẩm cứu trợ (**Item**), và Cửa hàng giao dịch (**Shop**).

* **Nguyễn Lê Anh Tuấn** (MSSV: `2300003`)
    * *Phân công nhiệm vụ:* Thiết kế xây dựng bản đồ ô gạch (**Map**), Thiết kế và tối ưu cấu trúc giao diện người dùng (**UI menu**), Thiết kế Màn hình điều khiển trung tâm (**MainMenu**).
