CREATE DATABASE QuanLySinhVien;
GO

USE QuanLySinhVien;
GO

CREATE TABLE TaiKhoan (
    MaTK INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL,
    MatKhau VARCHAR(255) NOT NULL,   -- tạm để plain text, sau này chúng ta hash
    Quyen VARCHAR(50) NOT NULL,      -- Admin, GiangVien, SinhVien
    MaNguoiDung VARCHAR(20) NULL     -- liên kết với GV hoặc SV
);
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Quyen, MaNguoiDung) 
VALUES ('admin', '1', 'Admin', NULL);

INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Quyen, MaNguoiDung) 
VALUES ('gv01', '1', 'GiangVien', 'GV001');

INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Quyen, MaNguoiDung) 
VALUES ('sv01', '1', 'SinhVien', 'SV001');
-- Tạo bảng Lớp trước (Vì Sinh viên cần mã lớp)
CREATE TABLE Lop (
    MaLop VARCHAR(10) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(10) -- Giả sử chưa tạo bảng Khoa thì cứ để vậy hoặc tạo bảng Khoa trước
);

-- Tạo bảng Sinh Viên
CREATE TABLE SinhVien (
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10),
    DiaChi NVARCHAR(200),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    MaLop VARCHAR(10) REFERENCES Lop(MaLop)
);

-- Thêm dữ liệu mẫu để test
INSERT INTO Lop (MaLop, TenLop) VALUES ('CNTTK62', N'Công nghệ thông tin K62');
INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaLop) 
VALUES ('SV001', N'Nguyễn Văn A', '2003-01-01', N'Nam', 'CNTTK62');
