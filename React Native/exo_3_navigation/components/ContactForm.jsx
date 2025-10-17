import { useContext, useState } from 'react';
import { ContactContext } from './ContactProvider';
import {
  View,
  Text,
  Pressable,
  Modal,
  StyleSheet,
  FlatList,
  Button,
  TextInput,
} from 'react-native';

export const ContactForm = ({ navigation }) => {
  const [name, setName] = useState('');
  const [phone, setPhone] = useState('');
  const [email, setEmail] = useState('');
  const { contacts, setContacts } = useContext(ContactContext);

  function submitForm() {
    setContacts((previous) => [
      ...previous,
      { name: name, phone: phone, email: email },
    ]);
    setName('');
    setPhone('');
    setEmail('');
    navigation.navigate('Home');
  }

  const namevalid =
    name.trim().length >= 3 && phone.trim() != '' && email.trim() != '';

  return (
    <View style={styles.container}>
      <View>
        <Text>Name</Text>
        <TextInput
          style={styles.input}
          value={name}
          onChangeText={setName}
          placeholder="Votre nom"
          autoCapitalize="words"
        />
        {!namevalid && <Text>3 caracteres minimum</Text>}
      </View>
      <View>
        <Text>Phone</Text>
        <TextInput
          style={styles.input}
          value={phone}
          onChangeText={setPhone}
          placeholder="Votre numero"
          autoCapitalize="none"
          keyboardType="phone-pad"
        />
      </View>
      <View>
        <Text>Email</Text>
        <TextInput
          style={styles.input}
          value={email}
          onChangeText={setEmail}
          placeholder="Votre email"
          autoCapitalize="none"
          keyboardType="words"
        />
      </View>
      <Button title="valider" onPress={submitForm} disabled={!namevalid} />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 70,
  },
  input: {
    borderWidth: 3,
    borderColor: '#000308ff',
    borderRadius: 8,
    fontSize: 16,
  },
});
