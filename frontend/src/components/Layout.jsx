import React from 'react';
import { NavLink, Outlet, useLocation } from 'react-router-dom';
const links = [['/','Tableau de bord'],['/hospitalisation','Hospitalisation'],['/stock','Stock matériel'],['/medecins','Médecins'],['/facturation','Facturation']];
const META = {
  '/':['Tableau de bord','Vue d’ensemble de l’hôpital'],
  '/hospitalisation':['Hospitalisation','Chambres et patients'],
  '/stock':['Stock matériel','Matériel médical et seuils'],
  '/medecins':['Médecins','Annuaire par spécialité'],
  '/facturation':['Facturation','Factures patients'],
};
export default function Layout() {
  const loc = useLocation();
  const [title,sub] = META[loc.pathname] || ['MediCare',''];
  return (
    <div className="app">
      <aside className="side">
        <div className="brand">Medi<span>Care</span></div>
        <div className="sub">Hospital ERP</div>
        <div className="lab">GESTION</div>
        <nav>{links.map(([t,l])=><NavLink key={t} to={t} end className={({isActive})=>isActive?'active':''}>{l}</NavLink>)}</nav>
        <div className="side-foot">ASP.NET Core · EF Core</div>
      </aside>
      <div className="main">
        <header className="topbar"><div className="tt"><h1>{title}</h1><div className="sub">{sub}</div></div>
          <div className="avatar">MC</div></header>
        <div className="content"><Outlet /></div>
      </div>
    </div>
  );
}
