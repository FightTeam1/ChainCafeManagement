var mongoose = require('mongoose')
var Schema = mongoose.Schema
var EmployeeTypeSchema = new Schema({
  code: {
    type: String,
    unique: [true, 'Mã loại nhân viên đã tồn tại'],
    required: [true, 'Mã loại nhân viên không được để trống'],
    max: [30, 'Mã loại nhân viên không được vượt quá 30 ký tự']
  },
  name: {
    type: String,
    required: [true, 'Tên loại nhân viên không được để trống'],
    max: [30, 'Tên loại nhân viên không được vượt quá 30 ký tự']
  }
})

module.exports = mongoose.model('EmployeeType', EmployeeTypeSchema, 'EmployeeType')