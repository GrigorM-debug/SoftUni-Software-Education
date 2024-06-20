const {Schema, model, SchemaTypes} = require('mongoose');

const volcanoSchema = new Schema({
    name: {
        type: String,
        required: true
    },
    location: {
        type: String,
        required: true
    },
    elevation: {
        type: Number,
        required: true
    },
    lastEruption: {
        type: Number,
        require: true
    },
    image: {
        type: String,
        required: true
    },
    typeVolcano: {
        type: String,
        required: true,
        enum: ["Supervolcanoes", "Submarine", "Subglacial", "Mud", "Stratovolcanoes", "Shield"]
    },
    description: {
        type: String,
        required: true
    },
    voteList: [{
        type: SchemaTypes.ObjectId,
        def: 'User',
        default: []
    }],
    owner: {
        type: SchemaTypes.ObjectId,
        def: 'User'
    }
});

const Volcano = model('Volcano', volcanoSchema);

module.exports ={Volcano};