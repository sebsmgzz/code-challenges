
const child_process = require('child_process');

child_process.exec('node ./challenge.js', (error, stdout, stderr) => {
    if(error) {
        console.log(stderr);
    }
    else {
        stdout = stdout.trim();
        const expected = '0b8781a3b9e2e8af92c419b860e09700d380baf9';
        console.log(`=== BackEndChallenge ===`);
        console.log(`   Given answer: ${stdout}`);
        console.log(`Expected answer: ${stdout}`);
        console.log(`=== ${expected == stdout? 'CORRECT' : 'INCORRECT'} ===`);
    }
});
