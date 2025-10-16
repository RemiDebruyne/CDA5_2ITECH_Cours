import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, Image } from 'react-native';
import { Info } from './components/Info';

export default function App() {
  return (
    <View style={styles.container}>
      <View style={circle}>
        <Text style={{ fontSize: 34 }}>R</Text>
      </View>
      <Text style={{ fontSize: 35, marginTop: 12 }}>Rémi</Text>
      <View style={{ marginTop: 24, gap: '14' }}>
        <Info
          imgSource={require('./assets/phone-call.png')}
          content={'06 01 02 03 04'}
        />
        <Info
          imgSource={require('./assets/at.png')}
          content={'remi@mail.com'}
        />
      </View>

      <StatusBar style="auto" />
    </View>
  );
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
});

const circle = StyleSheet.create({
  width: 120,
  height: 120,
  borderRadius: 120 / 2,
  backgroundColor: '#62db77ff',
  alignItems: 'center',
  justifyContent: 'center',
});
