import { useContext, useState } from 'react';
import {
  View,
  Text,
  Pressable,
  Modal,
  StyleSheet,
  FlatList,
  Button,
} from 'react-native';
import { ContactContext } from './ContactProvider';

export const ContactList = ({ navigation }) => {
  const circle = StyleSheet.create({
    width: 24,
    height: 24,
    borderRadius: 24 / 2,
    backgroundColor: '#c0c0c0ff',
    alignItems: 'center',
    justifyContent: 'center',
  });

  const { contacts, setContacts } = useContext(ContactContext);

  return (
    <View style={{ paddingTop: 24, alignItems: 'center' }}>
      <FlatList
        contentContainerStyle={{ gap: '10' }}
        style={{ padding: 16, width: '400' }}
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
              navigation.navigate('ContactInfo', item);
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

      <Button title="+" onPress={() => navigation.navigate('ContactForm')} />
    </View>
  );
};
