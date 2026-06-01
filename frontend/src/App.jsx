import React from 'react';
import { HashRouter, Routes, Route, Navigate } from 'react-router-dom';
import Layout from './components/Layout.jsx';
import Dashboard from './pages/Dashboard.jsx';
import Hospitalisation from './pages/Hospitalisation.jsx';
import Stock from './pages/Stock.jsx';
import Medecins from './pages/Medecins.jsx';
import Facturation from './pages/Facturation.jsx';
export default function App() {
  return (
    <HashRouter>
      <Routes>
        <Route element={<Layout />}>
          <Route path="/" element={<Dashboard />} />
          <Route path="/hospitalisation" element={<Hospitalisation />} />
          <Route path="/stock" element={<Stock />} />
          <Route path="/medecins" element={<Medecins />} />
          <Route path="/facturation" element={<Facturation />} />
        </Route>
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </HashRouter>
  );
}
