import { useQuery } from '@tanstack/vue-query'
import { nodesClient } from '../../../shared/rpc/clients'

export function useNodePreviews() {
  return useQuery({
    queryKey: ['nodes', 'previews'],
    queryFn: async () => {
      const response = await nodesClient.getPreviews({})
      return response.previews
    },
  })
}
