export const useCopyToClipboard = () => {
  const copyToClipboard = async (textToCopy) => {
    try {
      await navigator.clipboard.writeText(textToCopy);
    } catch (e) {
      console.error('probleme lors de la copie: ' + e);
    }
  };
  return { copyToClipboard };
};
