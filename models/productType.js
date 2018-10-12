var mongoose = require('mongoose')
var Schema = mongoose.Schema
var ProductTypeSchema = new Schema({
  code: {
    type: String,
    unique: true
  },
  name: {
    type: String,
    unique: true
  }
})

module.exports = mongoose.model('ProductType', ProductTypeSchema, 'ProductType')