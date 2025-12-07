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
