import { useState } from 'react';
import {
  View,
  Text,
  Pressable,
  Modal,
  StyleSheet,
  FlatList,
} from 'react-native';

import ContactPage from './ContactPage';

export const ContactList = () => {
  const circle = StyleSheet.create({
    width: 24,
    height: 24,
    borderRadius: 24 / 2,
    backgroundColor: '#c0c0c0ff',
    alignItems: 'center',
    justifyContent: 'center',
  });

  const contacts = [
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
  ];

  const [visible, setVisible] = useState(false);

  const [currentContact, setCurrentContact] = useState({});

  return (
    <View style={{ paddingTop: 24, alignItems: 'center' }}>
      <Text style={{ fontSize: 48 }}>Contacts</Text>
      <FlatList
        contentContainerStyle={{ gap: '10' }}
        style={{ flex: 1, padding: 16, width: '400' }}
        data={contacts}
        keyExtractor={(item) => item.id}
        renderItem={({ item }) => (
          <Pressable
            style={{
              borderRadius: 100 / 2,
              paddingHorizontal: 24,
              backgroundColor: 'rgba(100, 150, 21, 1)',
              flexDirection: 'row',
              justifyContent: 'space-between',
              alignItems: 'center',
            }}
            onPress={() => {
              setVisible(true);
              setCurrentContact(item);
            }}
          >
            <View style={circle}>
              <Text>{item.name.charAt(0)}</Text>
            </View>
            <View
              style={{
                flexDirection: 'row',
                justifyContent: 'space-between',
                marginHorizontal: '12',
                paddingVertical: 12,
              }}
            >
              <Text>{item.name}</Text>
            </View>
          </Pressable>
        )}
      />

      <Modal visible={visible}>
        <ContactPage
          userInfo={{
            name: currentContact.name,
            phone: currentContact.phone,
            email: currentContact.email,
          }}
          onReturnClick={() => setVisible(false)}
        />
      </Modal>
    </View>
  );
};
