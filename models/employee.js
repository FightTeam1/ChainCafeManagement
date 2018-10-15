var mongoose = require('mongoose')
var Schema = mongoose.Schema
var EmployeeSchema = new Schema({
  code: {
    type: String,
    unique: [true, 'Mã nhân viên đã tồn tại'],
    required: true,
    max: [30, 'Mã nhân viên không được vượt quá 30 ký tự']
  },
  firstName: {
    type: String,
    max: [30, 'Tên nhân viên không được vượt quá 30 ký tự']
  },
  lastName: {
    type: String,
    max: [30, 'Họ nhân viên không được vượt quá 30 ký tự']
  },
  type: {
    type: Schema.Types.ObjectId,
    ref: 'EmployeeType'
  },
  base: {
    type: Schema.Types.ObjectId,
    ref: 'Base'
  },
  phoneNumber: {
    type: String,
    max: [10, 'Số điện thoại không hợp lệ']
  },
  identifyCard: {
    type: String
  },
  email: {
    type: String,
    trim: true,
    lowercase: true,
    match: [/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/, 'Địa chỉ email không hợp lệ']
  },
  address: {
    type: String,
    max: [100, 'Địa chỉ không được vượt quá 100 ký tự']
  },
  password: {
    type: String
  }
})

module.exports = mongoose.model('Employee', EmployeeSchema, 'Employee')