import { StatusBar } from 'expo-status-bar';
import {
  StyleSheet,
  Text,
  View,
  Image,
  Button,
  Pressable,
  Linking,
  Alert,
} from 'react-native';
import { Info } from './Info';
export default function ContactPage({ userInfo, onReturnClick }) {
  const { name, phone, email } = userInfo;
  async function makeCall(phoneNumber) {
    // const possible = await Linking.canOpenURL('tel:+33012345678')
    const possible = await Linking.canOpenURL(phoneNumber);
    if (possible) {
      // await Linking.openURL('tel:+33012345678')
      await Linking.openURL(phoneNumber);
    } else {
      Alert.alert('Pas possible ici');
    }
  }

  const styles = StyleSheet.create({
    container: {
      marginTop: 50,
      flex: 1,
      backgroundColor: '#fff',
      alignItems: 'center',
      justifyContent: 'start',
    },
    info: {
      backgroundColor: '#dfdfdfff',
      width: '80%',
      paddingTop: 12,
      paddingBottom: 12,
      paddingHorizontal: 24,
      borderRadius: 240 / 2,
      flexDirection: 'row',
      justifyContent: 'space-between',
    },
    circle: {
      width: 120,
      height: 120,
      borderRadius: 120 / 2,
      backgroundColor: '#62db77ff',
      alignItems: 'center',
      justifyContent: 'center',
    },
  });

  return (
    <View style={styles.container}>
      <View style={styles.circle}>
        <Text style={{ fontSize: 34 }}>{name.charAt(0)}</Text>
      </View>
      <Text style={{ fontSize: 35, marginTop: 12 }}>{name}</Text>
      <View style={{ marginTop: 24, marginBottom: 24, gap: '14' }}>
        <Pressable
          style={{ width: '100%' }}
          onPress={() => {
            makeCall(phone);
          }}
        >
          <Info
            imgSource={require('../assets/phone-call.png')}
            content={phone}
          />
        </Pressable>
        <Info imgSource={require('../assets/at.png')} content={email} />
      </View>

      <StatusBar style="auto" />
      <Button onPress={onReturnClick} title="Retour" />
    </View>
  );
}
