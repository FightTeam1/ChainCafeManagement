var mongoose = require('mongoose')
var Schema = mongoose.Schema
var ProductSchema = new Schema({
  code: {
    type: String,
    unique: [true, 'Mã sản phẩm đã tồn tại'],
    required: [true, 'Thiếu mã sản phẩm']
  },
  name: {
    type: String,
    required: [true, 'Thiếu tên sản phẩm'],
    max: [50, 'Tên sản phẩm không được vượt quá 50 ký tự'],
    default: 'N/A'
  },
  type: {
    type: Schema.Types.ObjectId,
    ref: 'ProductType',
    required: [true, 'Thiếu loại sản phẩm']
  }
})

module.exports = mongoose.model('Product', ProductSchema, 'Product')