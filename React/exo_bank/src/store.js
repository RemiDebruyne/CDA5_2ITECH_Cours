import { configureStore, createSlice } from '@reduxjs/toolkit';

const dataSlice = createSlice({
  name: 'bankData',
  initialState: { value: [] },
  reducers: {
    addExpense: (state, action) => {
      state.value = [...state.value, action.payload];
    },
    removeExpense: (state, action) => {
      const index = state.value.findIndex(
        (expense) => expense.id == action.payload.id
      );
      if (index != -1) {
        state.value.splice(index, 1);
      }
    },
  },
});

export const { addExpense, removeExpense } = dataSlice.actions;

export const store = configureStore({
  reducer: {
    bankData: dataSlice.reducer,
  },
});
