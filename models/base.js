var mongoose = require('mongoose')
var Schema = mongoose.Schema
var BaseSchema = new Schema({
  code: {
    type: String,
    unique: [true, 'Mã cơ sở đã tồn tại'],
    required: [true, 'Mã cơ sở không được để trống'],
    max: [30, 'Mã cơ sở không được vượt quá 30 ký tự']
  },
  name: {
    type: String,
    required: [true, 'Tên cơ sở không được để trống'],
    max: [30, 'Tên cơ sở không được vượt quá 30 ký tự']
  },
  address: {
    type: String, 
    required: [true, 'Địa chỉ cơ sở không được để trống'],
    max: [100, 'Địa chỉ cơ sở không được vượt quá 100 ký tự']
  },
  phoneNumber: {
    type: String,
    max: [10, 'Số điện thoại cơ sở không hợp lệ']
  }
})

module.exports = mongoose.model('Base', BaseSchema, 'Base')