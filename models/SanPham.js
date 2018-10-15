var mongoose = require('mongoose')
var Schema = mongoose.Schema
var SanPhamSchema = new Schema({
  MaSP: {
    type: String,
    unique: [true, 'Mã sản phẩm đã tồn tại'],
    required: [true, 'Thiếu mã sản phẩm']
  },
  TenSP: {
    type: String,
    required: [true, 'Thiếu tên sản phẩm'],
    max: [50, 'Tên sản phẩm không được vượt quá 50 ký tự'],
    default: 'N/A'
  },
  MaLoaiSP: {
    type: String,
    required: [true, 'Thiếu mã loại sản phẩm']
  }
})

module.exports = mongoose.model('SanPham', SanPhamSchema, 'SanPham')