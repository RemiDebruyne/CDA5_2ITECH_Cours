import { StyleSheet, Text, View, Image } from 'react-native';

export const Info = ({ imgSource, content }) => {
  const styles = StyleSheet.create({
    info: {
      backgroundColor: '#dfdfdfff',
      width: '90%',
      paddingTop: 12,
      paddingBottom: 12,
      paddingHorizontal: 24,
      borderRadius: 240 / 2,
      flexDirection: 'row',
      justifyContent: 'space-between',
    },
  });

  return (
    <View style={styles.info}>
      <Image source={imgSource} />
      <Text>{content}</Text>
    </View>
  );
};
