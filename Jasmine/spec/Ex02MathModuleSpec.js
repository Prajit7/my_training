const app = require("../src/mathModule");
describe('Math Component', function() {
    
    it('Should add two number', ()=>{
        const input1 = 12;
        const input2= 23;
        const expected = 35;
        const actual = app.addFunc(input1,input2);
        expect(actual).toBe(expected);
    });
    it('Should subtract two number', ()=>{
        const input1 = 22;
        const input2= 2;
        const expected = 20;
        const actual = app.subFunc(input1,input2);
        expect(actual).toBe(expected);
    });
    it('Should Multiply two number', ()=>{
        const input1 = 22;
        const input2= 2;
        const expected = 44;
        const actual = app.mulFunc(input1,input2);
        expect(actual).toBe(expected);
    });
    it('Should subtract two number', ()=>{
        const input1 = 22;
        const input2= 2;
        const expected = 11;
        const actual = app.divFunc(input1,input2);
        expect(actual).toBe(expected);
    });
        
    
});
    