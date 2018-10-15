var mongoose = require('mongoose')
var Schema = mongoose.Schema
var BillSchema = new Schema({
  code: {
    type: String,
    unique: [true, 'Mã hóa đơn đã tồn tại'],
    max: [30, 'Mã hóa đơn không được vượt quá 30 ký tự'],
    required: [true, 'Mã hóa đơn không được để trống']
  },
  customer: {
    type: Schema.Types.ObjectId,
    ref: 'Customer',
    required: [true, 'Thiếu thông tin khách hàng']
  },
  employee: {
    type: Schema.Types.ObjectId,
    ref: 'Employee'
  },
  created: {
    type: Date,
    default: Date.now()  
  },
  totalPrice: {
    type: Number,
    default: 0
  },
  status: {
    type: String,
    enum: ['Đang chờ duyệt', 'Đã duyệt', 'Xong', 'Hủy'],
    default: 'Đang chờ duyệt'
  }
})

module.exports = mongoose.model('Bill', BillSchema, 'Bill')