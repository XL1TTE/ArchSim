<script setup lang="ts">
import GraphCanvas from './features/canvas/components/GraphCanvas.vue'
import NodePalette from './features/nodes/components/NodePalette.vue'
</script>

<template>
  <main style="position: relative; width: 100vw; height: 100vh; overflow: hidden;">
    <NodePalette />
    <GraphCanvas />
  </main>
</template>



