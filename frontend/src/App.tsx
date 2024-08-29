import React from 'react'
import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { Fridge, Landing, OpenProducts, ShutProducts } from './pages';
import { ChakraProvider } from '@chakra-ui/react';

function App() {

  return (
    <ChakraProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/" >
            <Route index element={<Landing />} />
            <Route path="fridge" element={<Fridge />} />
            <Route path="openProducts" element={<OpenProducts />} />
            <Route path="shutProducts" element={<ShutProducts />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </ChakraProvider>
  )
}

export default App
