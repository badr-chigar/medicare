import React, { useEffect, useState } from 'react';
import { api } from '../api.js';
export default function Facturation() {
  const [list,setList] = useState([]);
  const load = () => api.factures().then(setList);
  useEffect(()=>{ load(); }, []);
  async function payer(f){ await api.payer(f.id); load(); }
  return (
    <table>
      <thead><tr><th>Référence</th><th>Patient</th><th>Montant</th><th>Statut</th><th>Action</th></tr></thead>
      <tbody>
        {list.map(f=>(
          <tr key={f.id}>
            <td>{f.reference}</td><td>{f.patientNom}</td>
            <td>{f.montant.toLocaleString('fr-FR')} MAD</td>
            <td>{f.payee ? <span className="tag ok">Payée</span> : <span className="tag warn">Impayée</span>}</td>
            <td>{!f.payee && <button onClick={()=>payer(f)}>Encaisser</button>}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
