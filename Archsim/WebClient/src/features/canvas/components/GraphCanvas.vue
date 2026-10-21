<script setup lang="ts">
import { ref } from 'vue'
import { VueFlow, useVueFlow, type Node, type Edge, type Connection } from '@vue-flow/core'
import '@vue-flow/core/dist/style.css'
import '@vue-flow/core/dist/theme-default.css'
import styles from './GraphCanvas.module.css'

const nodes = ref<Node[]>([])
const edges = ref<Edge[]>([])

const { onConnect, screenToFlowCoordinate } = useVueFlow()

onConnect((params: Connection) => {
  edges.value.push({
    id: `edge-${params.source}-${params.target}`,
    source: params.source,
    target: params.target,
  })
})

function onDragOver(event: DragEvent) {
  event.preventDefault()
  if (event.dataTransfer) {
    event.dataTransfer.dropEffect = 'copy'
  }
}

function onDrop(event: DragEvent) {
  event.preventDefault()
  const typeId = event.dataTransfer?.getData('application/archsim-node-type')
  if (!typeId) return

  const position = screenToFlowCoordinate({
    x: event.clientX,
    y: event.clientY,
  })

  nodes.value.push({
    id: `node-${Date.now()}`,
    type: 'default',
    label: `${typeId} node`,
    position,
  })
}
</script>

<template>
  <div :class="styles.canvasContainer" @dragover="onDragOver" @drop="onDrop">
    <VueFlow :nodes="nodes" :edges="edges" :fit-view-on-init="true" />
  </div>
</template>
