var mongoose = require('mongoose')
var Schema = mongoose.Schema
var DetailBillSchema = new Schema({
  bill: {
    type: Schema.Types.ObjectId,
    ref: 'Bill',
    required: [true, 'Thiếu thông tin hóa đơn']
  },
  product: {
    type: Schema.Types.ObjectId,
    ref: 'Product',
    required: [true, 'Thiếu thông tin sản phẩm']
  },
  count: {
    type: Number,
    default: 0
  }
})

module.exports = mongoose.model('DetailBill', DetailBillSchema, 'DetailBill')