<script setup lang="ts">
import { useNodePreviews } from '../api/useNodePreviews'
import type { NodePreview } from '../../../contracts/rpc/Nodes/NodeTypes_pb'
import styles from './NodePalette.module.css'

const { data: previews, isLoading, isError, error } = useNodePreviews()

function onDragStart(event: DragEvent, node: NodePreview) {
  if (event.dataTransfer) {
    event.dataTransfer.setData('application/archsim-node-type', node.typeId)
    event.dataTransfer.effectAllowed = 'copy'
  }
}
</script>

<template>
  <aside :class="styles.palette">
    <div :class="styles.header">Available Nodes</div>

    <div v-if="isLoading" :class="styles.statusMessage">Loading previews...</div>
    <div v-else-if="isError" :class="[styles.statusMessage, styles.error]">
      Failed to load nodes: {{ error?.message }}
    </div>

    <ul v-else :class="styles.nodeList">
      <li
        v-for="node in previews"
        :key="node.typeId"
        :class="styles.nodeItem"
        draggable="true"
        :data-node-type="node.typeId"
        @dragstart="onDragStart($event, node)"
      >
        <span :class="styles.nodeName">{{ node.name }}</span>
        <span :class="styles.nodeDescription">{{ node.description }}</span>
      </li>
    </ul>
  </aside>
</template>
