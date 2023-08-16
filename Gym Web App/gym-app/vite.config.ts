import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  build: {
    outDir: "../wwwroot/client",
    emptyOutDir: true,
    rollupOptions: {
      input: [
        '../src/main.ts'
      ],
      output: {
        entryFileNames: `assets/js/[name].js`,
        chunkFileNames: `assets/js/[name].js`,
        assetFileNames: `assets/css/[name].[ext]`
      }
    }
  }
})
