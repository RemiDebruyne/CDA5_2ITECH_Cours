import { createContext, useState } from 'react';

export const ContactContext = createContext();

export function ContactProvider({ children }) {
  const [contacts, setContacts] = useState([
    {
      id: 1,
      name: 'Jean Bon',
      phone: '01 02 03 04 05',
      email: 'jean@mail.com',
    },
    {
      id: 2,
      name: 'Jean Pasbon',
      phone: '01 02 03 04 05',
      email: 'jean@mail.com',
    },
    {
      id: 3,
      name: 'Bob Bab',
      phone: '01 02 03 04 05',
      email: 'bob@mail.com',
    },
  ]);

  return (
    <ContactContext.Provider value={{ contacts, setContacts }}>
      {children}
    </ContactContext.Provider>
  );
}

export default ContactProvider;
