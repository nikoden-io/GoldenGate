const express = require('express');
const path = require('path');
const history = require('connect-history-api-fallback');

const app = express();

app.use((req, res, next) => {
  console.log(`Request URL: ${req.url}`);
  next();
});

const enPath = path.join(__dirname, '../dist/golden-front/browser/en');
console.log(`Serving English content from: ${enPath}`);
app.use('/en', express.static(enPath));

const frPath = path.join(__dirname, '../dist/golden-front/browser/fr');
console.log(`Serving French content from: ${frPath}`);
app.use('/fr', express.static(frPath));

const nlPath = path.join(__dirname, '../dist/golden-front/browser/nl');
console.log(`Serving Dutch content from: ${nlPath}`);
app.use('/nl', express.static(nlPath));

app.use(history({
  rewrites: [
    {from: /^\/en\/.*$/, to: '/en/index.html'},
    {from: /^\/fr\/.*$/, to: '/fr/index.html'},
    {from: /^\/nl\/.*$/, to: '/nl/index.html'},
  ],
}));

const PORT = process.env.PORT || 8080;
app.listen(PORT, () => {
  console.log(`Server is running at http://localhost:${PORT}`);
});
