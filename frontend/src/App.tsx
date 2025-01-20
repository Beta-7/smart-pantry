import React from 'react'
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Fridge, Landing, OpenProducts, ShutProducts } from './pages';

function App() {

  return (
      <BrowserRouter>
        <Routes>
          <Route path="/" >
            <Route index element={<Landing />} />
            <Route path="fridge" element={<Fridge />} />
            <Route path="openProducts" element={<OpenProducts />} />
            <Route path="stockedProducts" element={<ShutProducts />} />
          </Route>
        </Routes>
      </BrowserRouter>
  )
}

export default App
