-- 1. Sử dụng đúng Database
USE QuanLySinhVien;
GO

-- 2. Tạo bảng Lớp (Phải tạo trước SinhVien)
CREATE TABLE Lop (
    MaLop NVARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa NVARCHAR(20)
);

-- 3. Tạo bảng Sinh Viên
CREATE TABLE SinhVien (
    MaSV NVARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    DiaChi NVARCHAR(200),
    SoDienThoai NVARCHAR(20),
    Email NVARCHAR(100),
    MaLop NVARCHAR(20) REFERENCES Lop(MaLop)
);

-- 4. Tạo bảng Điểm/Kết quả
CREATE TABLE KetQua (
    MaSV NVARCHAR(20) REFERENCES SinhVien(MaSV),
    MaMonHoc NVARCHAR(20), 
    DiemLan1 FLOAT,
    DiemLan2 FLOAT,
    PRIMARY KEY (MaSV, MaMonHoc)
);

-- 5. Tạo bảng Học Phí (để Dashboard không bị lỗi khi tính tiền)
CREATE TABLE HocPhi (
    MaSV NVARCHAR(20) REFERENCES SinhVien(MaSV),
    TongTien DECIMAL(18, 0) DEFAULT 0,
    DaDong DECIMAL(18, 0) DEFAULT 0,
    ConNo AS (TongTien - DaDong),
    PRIMARY KEY (MaSV)
);

-- 6. Thêm dữ liệu mẫu (Để test)
INSERT INTO Lop (MaLop, TenLop) VALUES ('CNTT1', N'Công nghệ thông tin 1');
INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) 
VALUES ('SV001', N'Nguyễn Văn A', '2003-01-01', N'Nam', 'CNTT1');