import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import { StyleSheet, Text, View } from 'react-native';
import { ContactList } from './components/ContactList';
import ContactInfo from './components/ContactInfo';
import { ContactForm } from './components/ContactForm';
import ContactProvider from './components/ContactProvider';

const Stack = createNativeStackNavigator();

export default function App() {
  return (
    <ContactProvider>
      <NavigationContainer>
        <Stack.Navigator
          initialRouteName="Home"
          screenOptions={{ headerTitleAlign: 'center' }}
        >
          <Stack.Screen
            name="Home"
            component={ContactList}
            options={{ title: 'Contacts', headerBackVisible: false }}
          />
          <Stack.Screen
            name="ContactInfo"
            component={ContactInfo}
            options={{ title: 'Contact information', headerBackVisible: true }}
          />
          <Stack.Screen
            name="ContactForm"
            component={ContactForm}
            options={{ title: 'Contact Form', headerBackVisible: true }}
          />
        </Stack.Navigator>
      </NavigationContainer>
    </ContactProvider>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
