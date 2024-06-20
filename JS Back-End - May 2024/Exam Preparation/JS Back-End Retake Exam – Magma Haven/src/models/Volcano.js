const {Schema, model, SchemaTypes} = require('mongoose');

const volcanoSchema = new Schema({
    name: {
        type: String,
        required: [true, 'Name is required'],
        min: [2, 'Name must be at least 2 characters long !']
    },
    location: {
        type: String,
        required: [true, 'Location is required !'],
        min: [3, 'Location must be at least 3 characters long !']
    },
    elevation: {
        type: Number,
        required: [true, 'Elevation is required !'],
        min: [0, 'Elevation must be at least 0 !']
    },
    lastEruption: {
        type: Number,
        require: [true, 'Year of Last Eruption is required !'],
        min: [0, "Year of Last Eruption must at least 0 !"],
        max: [2024, "Year of Last Eruption must at least 0 !"]
    },
    image: {
        type: String,
        required: [true, 'Image is required'],
        match: [/^(http:\/\/|https:\/\/)/, 'Invalid image URL!']
    },
    typeVolcano: {
        type: String,
        required: [true, 'Volcano type is required !'],
        enum: {
            values: ["Supervolcanoes", "Submarine", "Subglacial", "Mud", "Stratovolcanoes", "Shield"],
            message: 'The value `{VALUE}` is not supported for the volcano type.'
        }
    },
    description: {
        type: String,
        required: [true, 'Description is required !'],
        min: [10, 'Description must at least 10 characters long !']
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