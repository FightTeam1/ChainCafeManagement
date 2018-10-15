var mongoose = require('mongoose')
var Schema = mongoose.Schema
var LoaiSPSchema = new Schema({
  MaLoaiSP: {
    type: String,
    unique: [true, 'Mã loại sản phẩm đã tồn tại'],
    required: [true, 'Mã loại sản phẩm không được để trống']
  },
  TenLoaiSP: {
    type: String,
    required: [true, 'Tên loại sản phẩm không được để trống']
  }
})

module.exports = mongoose.model('LoaiSP', LoaiSPSchema, 'LoaiSP')