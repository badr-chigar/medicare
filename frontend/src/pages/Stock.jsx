import React, { useEffect, useState } from 'react';
import { api } from '../api.js';
export default function Stock() {
  const [list,setList] = useState([]);
  const load = () => api.materiel().then(setList);
  useEffect(()=>{ load(); }, []);
  async function utiliser(m){ const q=+prompt('Quantité utilisée ?','1'); if(q>0){ await api.utiliser(m.id,q); load(); } }
  return (
    <table>
      <thead><tr><th>Matériel</th><th>Stock</th><th>Seuil</th><th>État</th><th>Action</th></tr></thead>
      <tbody>
        {list.map(m=>(
          <tr key={m.id}>
            <td><b>{m.nom}</b></td>
            <td>{m.stock} {m.unite}</td>
            <td>{m.seuil}</td>
            <td>{m.stock<=m.seuil ? <span className="tag warn">Réappro</span> : <span className="tag ok">OK</span>}</td>
            <td><button onClick={()=>utiliser(m)}>Utiliser</button></td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
