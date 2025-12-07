USE QuanLySinhVien;
GO

-- =============================================
-- 1. TẠO BẢNG GIẢNG VIÊN
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GiangVien]') AND type in (N'U'))
BEGIN
    CREATE TABLE GiangVien (
        MaGV NVARCHAR(20) PRIMARY KEY,
        HoTen NVARCHAR(100) NOT NULL,
        GioiTinh NVARCHAR(10),
        SoDienThoai NVARCHAR(20),
        Email NVARCHAR(100),
        DiaChi NVARCHAR(200)
    );
    -- Thêm dữ liệu mẫu
    INSERT INTO GiangVien (MaGV, HoTen, GioiTinh, SoDienThoai, Email) 
    VALUES ('GV001', N'Trần Thị B', N'Nữ', '0912345678', 'gv01@example.com');
    INSERT INTO GiangVien (MaGV, HoTen, GioiTinh, SoDienThoai, Email) 
    VALUES ('GV002', N'Lê Văn C', N'Nam', '0987654321', 'gv02@example.com');
END
GO

-- =============================================
-- 2. TẠO BẢNG MÔN HỌC
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonHoc]') AND type in (N'U'))
BEGIN
    CREATE TABLE MonHoc (
        MaMonHoc NVARCHAR(20) PRIMARY KEY,
        TenMonHoc NVARCHAR(100) NOT NULL,
        SoTinChi INT DEFAULT 3,
        MaGV NVARCHAR(20) REFERENCES GiangVien(MaGV) -- Môn này do ai dạy
    );
    -- Thêm dữ liệu mẫu
    INSERT INTO MonHoc (MaMonHoc, TenMonHoc, SoTinChi, MaGV) VALUES ('CSDL', N'Cơ sở dữ liệu', 3, 'GV001');
    INSERT INTO MonHoc (MaMonHoc, TenMonHoc, SoTinChi, MaGV) VALUES ('LTC', N'Lập trình C#', 4, 'GV002');
END
GO

-- =============================================
-- 3. TẠO BẢNG KẾT QUẢ HỌC TẬP (ĐIỂM)
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[KetQua]') AND type in (N'U'))
BEGIN
    CREATE TABLE KetQua (
        MaSV NVARCHAR(20) REFERENCES SinhVien(MaSV), -- Link với SinhVien
        MaMonHoc NVARCHAR(20) REFERENCES MonHoc(MaMonHoc), -- Link với MonHoc
        DiemLan1 FLOAT DEFAULT 0,
        DiemLan2 FLOAT DEFAULT 0,
        PRIMARY KEY (MaSV, MaMonHoc) -- Một SV không thể học 1 môn 2 lần trong bảng này
    );
    -- Thêm dữ liệu mẫu (Giả sử đã có SV001 từ bước trước)
    INSERT INTO KetQua (MaSV, MaMonHoc, DiemLan1, DiemLan2) VALUES ('SV001', 'CSDL', 8.5, 0);
    INSERT INTO KetQua (MaSV, MaMonHoc, DiemLan1, DiemLan2) VALUES ('SV001', 'LTC', 4.0, 7.5);
END
GO

-- =============================================
-- 4. TẠO BẢNG HỌC PHÍ
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HocPhi]') AND type in (N'U'))
BEGIN
    CREATE TABLE HocPhi (
        MaSV NVARCHAR(20) PRIMARY KEY REFERENCES SinhVien(MaSV), -- Mỗi SV có 1 hồ sơ học phí
        TongTien DECIMAL(18, 0) DEFAULT 0, -- Tổng học phí phải đóng
        DaDong DECIMAL(18, 0) DEFAULT 0    -- Số tiền đã đóng
        -- Cột "Còn Nợ" sẽ tự tính trong code C# hoặc dùng Computed Column
    );
    -- Thêm dữ liệu mẫu
    INSERT INTO HocPhi (MaSV, TongTien, DaDong) VALUES ('SV001', 5000000, 2000000);
END
GO

-- =============================================
-- 5. CẬP NHẬT BẢNG TÀI KHOẢN (HỆ THỐNG)
-- =============================================
-- Đảm bảo bảng TaiKhoan có cột MaNguoiDung để liên kết (Admin thì NULL, SV thì mã SV, GV thì mã GV)
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'[dbo].[TaiKhoan]') AND name = 'MaNguoiDung')
BEGIN
    ALTER TABLE TaiKhoan ADD MaNguoiDung NVARCHAR(20) NULL;
END
GO

-- Xóa dữ liệu cũ của TaiKhoan để thêm lại cho chuẩn (nếu cần)
DELETE FROM TaiKhoan WHERE TenDangNhap IN ('admin', 'gv01', 'sv01');

-- Thêm 3 tài khoản mẫu chuẩn
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Quyen, MaNguoiDung) VALUES ('admin', '1', 'Admin', NULL);
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Quyen, MaNguoiDung) VALUES ('gv01', '1', 'GiangVien', 'GV001');
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Quyen, MaNguoiDung) VALUES ('sv01', '1', 'SinhVien', 'SV001');

GO