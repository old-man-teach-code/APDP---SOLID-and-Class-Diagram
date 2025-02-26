# SOLID - Nguyên lý thiết kế hướng đối tượng
======================================
- S - Single Responsibility Principle: Mỗi lớp chỉ có một trách nhiệm duy nhất
- O - Open/Closed Principle: Các lớp nên mở rộng được mà không được sửa đổi code cũ
- L - Liskov Substitution Principle: Các lớp con có thể thay thế lớp cha mà **không làm thay đổi tính đúng đắn**
- I - Interface Segregation Principle: Chia nhỏ các interface thành nhiều interface nhỏ hơn, cụ thể hơn, mục tiêu là giảm sự phụ thuộc của các lớp.
- D - Dependency Inversion Principle: Các module cấp cao không nên phụ thuộc vào các module cấp thấp, cả hai nên phụ thuộc vào trừu tượng, phụ thuộc vào interface

=====================================
# Class Diagram
- Association (liên kết): Một lớp có thể truy cập đến một lớp khác thông qua một thuộc tính hoặc phương thức
- Generalization (tổng quát hóa): Một lớp có thể kế thừa từ một lớp khác
- Specialization (cụ thể hóa): Một lớp có thể kế thừa từ một lớp khác
(Generalization và Specialization tạo thành một mối quan hệ kế thừa)

## Cấu trúc Class Diagram
- Class: Tên lớp
- Attribute: Thuộc tính của lớp
- Method: Phương thức của lớp
- Visibility: Phạm vi truy cập của thuộc tính hoặc phương thức. Ký hiệu: `+` (public), `-` (private), `#` (protected)
Ví dụ:
```
---------------------------------
|           Student             |
---------------------------------
| - id: int                     |
| - name: String                |
| - age: int                    |
---------------------------------
| + setId(id: int): void        |
| + getId(): int                |
| + setName(name: String): void |
| + getName(): String           |
| + setAge(age: int): void      |
| + getAge(): int               |
---------------------------------
```


## Mối quan hệ giữa các lớp
- Navigability (điều hướng): Một lớp có thể truy cập đến một lớp khác thông qua một thuộc tính hoặc phương thức. Ký hiệu: `-->`
•Multiplicity (đa hướng): Số lượng lớp mà một lớp có thể truy cập. Ký hiệu: `1`, `0..1`, `*`, `1..*`, `m..n`, <`m..n`>
- Dependency: Một lớp có thể phụ thuộc vào một lớp khác, nếu lớp phụ thuộc thay đổi thì lớp phụ thuộc cũng phải thay đổi. Nhưng sự phụ thuộc này không ảnh hưởng đến vòng đời của lớp phụ thuộc. Ký hiệu: `--|>`
- Aggregation: Một lớp có thể chứa một hoặc nhiều lớp khác, nhưng các lớp này không phụ thuộc vào nhau. Lớp con có thể tồn tại mà không cần lớp cha. Ký hiệu: `<>--` (hình kim cương không tô đậm)
- Composition: Một lớp có thể chứa một hoặc nhiều lớp khác, nhưng các lớp này phụ thuộc vào nhau. Lớp con không thể tồn tại mà không cần lớp cha. Ký hiệu: `<>--` (hình kim cương tô đậm)
- Inheritance: Một lớp con có thể kế thừa các thuộc tính và phương thức từ một lớp cha. Ký hiệu: `--|>` (mũi tên hở)
- Interface: Một lớp có thể thực thi một hoặc nhiều giao diện. Ký hiệu: `- - -|>` (mũi tên hở)
## Inheritance and Interface
- Inheritance (kế thừa): Một lớp con có thể kế thừa các thuộc tính và phương thức từ một lớp cha, inheritance dùng với mục đích tái sử dụng code
- Interface (giao diện): Một lớp có thể thực thi một hoặc nhiều giao diện, interface dùng với mục đích thiết lập một chuẩn cho các lớp khác. Chú ý: Khi đã sử dụng interface thì không giao tiếp trực tiếp với lớp mà thông qua interface, giúp giảm sự phụ thuộc giữa các lớp, nếu có bất kỳ sự thay đổi logic gì thì giao tiếp thông qua interface sẽ không bị ảnh hưởng.