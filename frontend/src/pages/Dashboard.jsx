import React, { useEffect, useState } from 'react';
import { api } from '../api.js';
export default function Dashboard() {
  const [s,setS] = useState(null);
  useEffect(()=>{ api.stats().then(setS).catch(()=>{}); }, []);
  if (!s) return <div className="muted">…</div>;
  const cards = [
    ['Taux d’occupation', s.tauxOccupation+' %','accent'],
    ['Patients hospitalisés', s.patients,'purple'],
    ["Chiffre d'affaires", Math.round(s.chiffreAffaires).toLocaleString('fr-FR')+' MAD','ok'],
    ['Ruptures de stock', s.rupturesStock, s.rupturesStock>0?'warn':'ok'],
  ];
  return (
    <div>
      <div className="kpis">
        {cards.map(([l,v,c])=><div key={l} className={'kpi '+c}><div className="kpi-v">{v}</div><div className="kpi-l">{l}</div></div>)}
      </div>
      <h2>Chambres : {s.occupees}/{s.chambres} occupées · {s.medecins} médecins</h2>
      <p className="muted">Montant impayé : {Math.round(s.impaye).toLocaleString('fr-FR')} MAD</p>
    </div>
  );
}
