var mongoose = require('mongoose')
var Schema = mongoose.Schema
var ProductTypeSchema = new Schema({
  code: {
    type: String,
    unique: [true, 'Mã loại sản phẩm đã tồn tại'],
    required: [true, 'Mã loại sản phẩm không được để trống']
  },
  name: {
    type: String,
    required: [true, 'Tên loại sản phẩm không được để trống']
  }
})

module.exports = mongoose.model('ProductType', ProductTypeSchema, 'ProductType')