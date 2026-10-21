import vue from '@vitejs/plugin-vue'
import { defineConfig } from 'vite'

// https://vite.dev/config/
export default defineConfig({
  plugins: [vue()],
  envPrefix: ['VITE_', 'ARCHSIM_'],
  server: {
    host: '0.0.0.0',
  },
})

