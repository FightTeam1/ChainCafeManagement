var mongoose = require('mongoose')
var Schema = mongoose.Schema
var ProductTypeSchema = new Schema({
  code: {
    type: String,
    unique: [true, 'Mã loại sản phẩm đã tồn tại']
  },
  name: {
    type: String,
    unique: [true, 'Tên loại sản phẩm đã tồn tại']
  }
})

module.exports = mongoose.model('ProductType', ProductTypeSchema, 'ProductType')