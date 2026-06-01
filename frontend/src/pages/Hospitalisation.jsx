import React, { useEffect, useState } from 'react';
import { api } from '../api.js';
export default function Hospitalisation() {
  const [list,setList] = useState([]);
  const load = () => api.chambres().then(setList);
  useEffect(()=>{ load(); }, []);
  async function admettre(c){
    const nom = prompt('Nom du patient ?'); if(!nom) return;
    await api.admettre(c.id, { patientNom: nom, age: 40, diagnostic: 'À évaluer' }); load();
  }
  async function liberer(c){ await api.liberer(c.id); load(); }
  return (
    <div className="grid-rooms">
      {list.map(c=>(
        <div className={'room '+(c.statut==='OCCUPEE'?'occ':'free')} key={c.id}>
          <div className="room-head"><b>{c.numero}</b><span className="tag">{c.service}</span></div>
          {c.statut==='OCCUPEE' ? (
            <>
              <div className="room-patient">{c.patient ? c.patient.nom : 'Patient'}</div>
              <div className="muted">{c.patient ? c.patient.diagnostic : ''}</div>
              <button className="link-danger" onClick={()=>liberer(c)}>Libérer</button>
            </>
          ) : (
            <>
              <div className="room-free">Chambre libre</div>
              <button onClick={()=>admettre(c)}>Admettre un patient</button>
            </>
          )}
        </div>
      ))}
    </div>
  );
}
