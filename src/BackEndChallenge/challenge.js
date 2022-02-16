/*
In the javascript file, write a program to perform a GET request on the route ...
which contains a data key and the value is a string which contains items in the 
format: key=STRING, age=INTEGER. Your goal is to count how many items exist that 
have an age equal to 32. Then you should create a write stream to a file called 
output.txt and the contents should be the key values (from the json) each on a 
separate line in the order the appeared in the json file (the file should end with 
a newline character on its oen line). Finally, then output the SHA1 hash of the file.
*/
const https = require('https');
const fs = require('fs');
const crypto = require('crypto');

function pairElements(elements) {
    return elements.reduce((out, value, index, array) => {
      if(index % 2 === 0) {
        out.push(array.slice(index, index + 2));
      }
      return out;
    }, []);
  }
  
  function pair2json(pair) {
    const obj = {};
    pair.forEach(str => {
      const assignment = str.trim().split('=');
      obj[assignment[0]] = assignment[1];
    });
    return obj;
  }

// TODO: Define url, the body should be the same as the response.txt
https.get('', function(response) {
  let rawData = '';
  response.setEncoding('utf8');
  response.on('data', data => rawData += data);
  response.on('end', function() {

    // Parse/clean data into actual list of jsons
    const content = JSON.parse(rawData);
    const elements = content.data.split(',');
    const pairs = pairElements(elements);
    const list = [];
    pairs.forEach(p => list.push(pair2json(p)));

    // Select and join all the keys from obj with age equals to 32
    const output = list
      .filter(pair => pair.age === '32')
      .map(pair => pair.key)
      .join('\n') + '\n';

    // Write to file
    fs.writeFile('output.txt', output, 'utf8', function(e) {
      const buffer = fs.readFileSync('output.txt');
      const hash = crypto.createHash('sha1');
      hash.update(buffer);
      const hex = hash.digest('hex');
      console.log(hex);
    });

  });
});
