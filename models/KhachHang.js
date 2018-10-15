var mongoose = require('mongoose')
var Schema = mongoose.Schema

var KhachHangSchema = new Schema({
  TenDangNhap: {
    type: String,
    unique: true,
    required: true,
    min: [5, 'Tên đăng nhập phải chứa ít nhất 5 ký tự'],
    max: [20, 'Tên đăng nhập không được vượt quá 20 ký tự']
  },
  HoTen: {
    type: String,
    default: 'No name',
    required: [true, 'Tên người dùng không được để trống'],
    max: [30, 'Tên người dùng không được vượt quá 30 ký tự']
  },
  Sdt: {
    type: String,
    max: [10, 'Số điện thoại phải đủ 10 ký tự số']
  },
  Email: {
    type: String,
    trim: true,
    lowercase: true,
    match: [/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/, 'Địa chỉ email không hợp lệ']
  },
  Diem: {
    type: Number,
    default: 0
  },
  MatKhau: {
    type: String,
    required: true
  }
})

module.exports = mongoose.model('KhachHang', KhachHangSchema, 'KhachHang')