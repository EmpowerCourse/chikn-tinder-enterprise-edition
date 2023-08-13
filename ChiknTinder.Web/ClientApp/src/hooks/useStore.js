import { create } from "zustand";

const useStore = create((set) => ({
  currentUser: null,
  setCurrentUser: (x) => set((state) => ({ ...state, currentUser: x })),
}));

export default useStore;
