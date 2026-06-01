import React, { useEffect, useState } from 'react';
import { api } from '../api.js';
export default function Medecins() {
  const [list,setList] = useState([]);
  useEffect(()=>{ api.medecins().then(setList); }, []);
  return (
    <div className="grid-doc">
      {list.map(m=>(
        <div className="doc" key={m.id}>
          <div className="doc-av">{m.nom.split(' ').slice(-1)[0][0]}</div>
          <div><b>{m.nom}</b><div className="muted">{m.specialite}</div><div className="muted">{m.telephone}</div></div>
        </div>
      ))}
    </div>
  );
}
