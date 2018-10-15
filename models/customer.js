var mongoose = require('mongoose')
var Schema = mongoose.Schema

var CustomerSchema = new Schema({
  loginName: {
    type: String,
    unique: true,
    required: true,
    min: [5, 'Tên đăng nhập phải chứa ít nhất 5 ký tự'],
    max: [20, 'Tên đăng nhập không được vượt quá 20 ký tự']
  },
  fullName: {
    type: String,
    default: 'No name',
    required: [true, 'Tên người dùng không được để trống'],
    max: [30, 'Tên người dùng không được vượt quá 30 ký tự']
  },
  phoneNumber: {
    type: String,
    max: [10, 'Số điện thoại phải đủ 10 ký tự số']
  },
  email: {
    type: String,
    trim: true,
    lowercase: true,
    match: [/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/, 'Địa chỉ email không hợp lệ']
  },
  score: {
    type: Number,
    default: 0
  },
  password: {
    type: String,
    required: true
  }
})

module.exports = mongoose.model('Customer', CustomerSchema, 'Customer')