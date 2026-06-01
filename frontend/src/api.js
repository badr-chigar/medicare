const BASE='/api';
async function req(p,o={}){ const r=await fetch(BASE+p,{headers:{'Content-Type':'application/json'},...o});
  if(!r.ok) throw new Error((await r.json().catch(()=>({}))).error||'Erreur serveur'); return r.status===204?null:r.json(); }
export const api = {
  chambres: () => req('/chambres'),
  admettre: (id,d) => req(`/chambres/${id}/admettre`,{method:'POST',body:JSON.stringify(d)}),
  liberer: (id) => req(`/chambres/${id}/liberer`,{method:'POST'}),
  materiel: () => req('/materiel'),
  utiliser: (id,quantite) => req(`/materiel/${id}/utiliser`,{method:'POST',body:JSON.stringify({quantite})}),
  reappro: (id,quantite) => req(`/materiel/${id}/reappro`,{method:'POST',body:JSON.stringify({quantite})}),
  medecins: () => req('/medecins'),
  factures: () => req('/factures'),
  payer: (id) => req(`/factures/${id}/payer`,{method:'POST'}),
  stats: () => req('/stats'),
};
